using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue Bob (1), Tim (5), Sue (3). Dequeue twice.
    // Expected Result: First dequeue returns Tim because it has the highest priority.
    // Second dequeue returns Sue because Tim should have been removed from the queue.
    // Defect(s) Found: The dequeued item was not removed from the queue, so the same highest-priority item was returned again.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 1);
        priorityQueue.Enqueue("Tim", 5);
        priorityQueue.Enqueue("Sue", 3);

        var first = priorityQueue.Dequeue();
        Assert.AreEqual("Tim", first);

        var second = priorityQueue.Dequeue();
        Assert.AreEqual("Sue", second);
    }

    [TestMethod]
    // Scenario: Enqueue Bob (1), Tim (3), Sue (3), George (5). Dequeue once.
    // Expected Result: George should be returned because it has the highest priority,
    // even though it was added last.
    // Defect(s) Found: The loop did not check the last item in the queue, so the highest-priority
    // item at the end could be missed.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 1);
        priorityQueue.Enqueue("Tim", 3);
        priorityQueue.Enqueue("Sue", 3);
        priorityQueue.Enqueue("George", 5);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("George", result);
    }

    [TestMethod]
    // Scenario: Enqueue Bob (5), Tim (5), Sue (3). Dequeue once.
    // Expected Result: Bob should be returned because Bob and Tim have the same highest priority,
    // and the queue must use FIFO order for ties.
    // Defect(s) Found: The code chose the most recently found item with the same priority instead
    // of the first one in the queue, violating FIFO for tied priorities.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 5);
        priorityQueue.Enqueue("Tim", 5);
        priorityQueue.Enqueue("Sue", 3);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Bob", result);
    }

    [TestMethod]
    // Scenario: Dequeue from an empty priority queue.
    // Expected Result: An InvalidOperationException should be thrown with the message
    // "The queue is empty."
    // Defect(s) Found: No defect found if the correct exception and message are thrown.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                    e.GetType(), e.Message)
            );
        }
    }
}