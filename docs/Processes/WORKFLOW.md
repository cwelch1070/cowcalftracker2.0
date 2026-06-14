# Engineering-Led AI Workflow

_Using AI to improve understanding, quality, and delivery while maintaining engineering ownership._

## Disclaimer

This document describes a workflow that has been effective for me. It is not intended to be a standard that everyone must follow, nor is it intended to prescribe a single way of working with AI.

The primary goal is to use AI in a way that improves understanding, accelerates development, and increases software quality while keeping the engineer responsible for design and implementation decisions.

Different engineers may prefer different approaches. Some may use AI primarily for discussion and design review. Others may use it more heavily for implementation. Both approaches are valid if they produce good outcomes.

The most important concept in this document is intentional use of AI. Model selection, reasoning level, context management, and task selection all influence the quality and cost of the results. AI is most effective when it is used as a tool to augment engineering judgment rather than replace it.

Use the pieces of this workflow that provide value, adapt the parts that do not, and continuously refine your approach as both the tools and your experience evolve.

## Purpose

Use AI to improve understanding, validate decisions, and accelerate implementation while maintaining ownership of architecture and design decisions.

The goal is not to have AI write software independently. The goal is to use AI to amplify engineering effectiveness.

---

# Core Principles

## 1. The Engineer Owns Decisions

AI may:

- Explain
    
- Challenge assumptions
    
- Identify tradeoffs
    
- Review plans
    
- Execute bounded tasks
    

AI does not own:

- Architecture
    
- Domain modeling
    
- Module boundaries
    
- Final implementation decisions
    

The engineer remains accountable for all decisions.

---

## 2. Use the Right Model for the Job

Not every task requires the most powerful model.

### Reasoning Models

Examples:

- Opus
    
- GPT-5
    
- Other frontier reasoning models
    

Use for:

- Architecture discussions
    
- Design reviews
    
- Tradeoff analysis
    
- Domain modeling
    
- Planning
    
- Understanding unfamiliar areas of the codebase
    

These models are optimized for thinking.

---

### Coding Models

Examples:

- Codex
    
- Similar implementation-focused models
    

Use for:

- Implementing approved designs
    
- Refactoring
    
- Code reviews
    
- Test generation
    
- Feature implementation
    

These models are optimized for execution.

---

### Utility Models

Examples:

- GPT-5 Mini
    
- Other low-cost utility models
    

Use for:

- Import corrections
    
- File moves
    
- Renames
    
- Barrel export updates
    
- Compile error cleanup
    
- Mechanical code maintenance
    

These models are optimized for simple, bounded tasks.

---

# Workflow

## Step 1: Understand the Problem

Use a reasoning model to discuss:

- Requirements
    
- Constraints
    
- Existing architecture
    
- Potential risks
    
- Ownership boundaries
    

Focus on understanding before implementation.

Questions may include:

- Does this violate module boundaries?
    
- Is code duplication acceptable here?
    
- Where should this capability live?
    
- Is my concern valid?
    

**This is pretty much just a brain dump of what you know about the problem, uncertainties you have, solutions you have in mind, and the general direction you would like to go. Include any files you would like the model to have as context in this step. This could be code files or Markdown files for custom instructions you like to use. This step is arguably the most important because it sets the tone for the session moving forward.**

**Be sure to say in your initial message something along the lines of, "Do not make any file changes yet. You are in chat-only mode," or it will start executing on your initial message.**

---

## Step 2: Validate the Design

Use the reasoning model to review the proposed solution.

The objective is to:

- Confirm assumptions
    
- Identify architectural concerns
    
- Evaluate tradeoffs
    
- Refine implementation approach
    

The goal is confidence, not code generation.

**Think of this step like rubber ducking or using the model as a thinking partner. Don't hesitate to go back and forth with it. Let it challenge you, and make sure you challenge it. I have had great success in this step finding patterns that fit the problem I am trying to solve, which has greatly increased the maintainability of the code I have produced.**

---

## Step 3: Create an Implementation Plan

Once the design is understood:

- Break work into small steps
    
- Define target files or modules
    
- Identify dependencies
    
- Identify risks
    

Keep plans focused and actionable.

**I would strongly suggest creating a plan for each step depending on how big the issue or feature you are working on is. I would advise against letting it form a plan that crosses boundaries or gets anywhere close to solving the full problem. Scope it how you would approach the problem if you did not have AI at all. Create a plan for this step. Later, define the next steps and create another plan. There are also other ways you can manipulate it by using one plan, but I like to think in steps and make things small.**

**In the Copilot CLI tool, you can build context up in your chat in the previous two steps and then run `/plan` (instructions for how you would like it to create the plan go here), and it will formulate a `plan.md` file. This will do the steps outlined above in Step 3 for you, and then you can validate the plan.**

**The Copilot CLI tool also has a `/rubberduck` command that will review your `plan.md` file. I have not used it much yet, and it is very agent-to-agent oriented, but you can intervene and leverage it to review the plan you guided the creation of.**

**Note: Copilot is very heavy on the agentic workflow. It wants to solve your problem for you and will go straight to implementation. If you explicitly tell it not to do this, it won't. Otherwise, it will create the plan and start implementation. It will also eat a ton of credits in this process if it is allowed to run wild.**

---

## Step 4: Execute the Plan

Use a coding model or utility model depending on complexity.

### Coding Model

Use when implementation requires reasoning:

- New business logic
    
- Complex refactoring
    
- Multiple interacting systems
    

### Utility Model

Use when implementation is mechanical:

- Moving files
    
- Updating imports
    
- Renaming symbols
    
- Fixing references
    

**Codex is great at implementation, but make sure you actually need it. It will eat more credits than you expect. I would also suggest that before telling Copilot to begin implementation, you reiterate the implementation rules again. These should also be laid out in the `plan.md`.**

---

## Step 5: Review the Result

Review:

- Architecture
    
- Boundary compliance
    
- Maintainability
    
- Correctness
    

Do not assume generated code is correct.

**The Copilot CLI tool has a `/review` feature that will perform code review on the diff. I find it very helpful for guiding my review and bringing my attention to places that may need it.**

**I use this feature for my own code regardless of whether I utilized this workflow or not to make sure my solution is as good as possible.**

---

# Managing Cost and Credits

Model selection matters.

Use expensive models only when reasoning is required.

Avoid using high-end models for tasks such as:

- Renaming files
    
- Updating imports
    
- Fixing references
    
- Resolving simple compile errors
    

Reserve reasoning models for problems that require judgment.

**You can also change the reasoning level on the model, and this will help. This will also speed up responses.**

---

# Context Management

Long-running discussions are valuable but expensive.

Periodically:

- Summarize key decisions
    
- Capture assumptions
    
- Capture constraints
    
- Capture next steps
    

Use summaries as working memory to reduce context size and credit consumption.

**In the Copilot CLI tool, you can run `/compact`, and it will summarize your session and create a checkpoint. You can do this as often as you would like.**

---

# Success Criteria

A successful AI interaction should:

- Improve understanding
    
- Increase confidence
    
- Validate decisions
    
- Reduce mechanical work
    

The primary measure of success is not code generated.

The primary measure of success is improved engineering judgment and execution.

**And most importantly, a tool should make your job easier and improve your work. If it isn't, change it.**